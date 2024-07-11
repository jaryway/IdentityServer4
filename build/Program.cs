using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Bullseye.Targets;
using static SimpleExec.Command;


namespace build
{
    partial class Program
    {
        private const string solution = "Jaryway.IdentityServer.sln";
        private const string packOutput = "./artifacts";
        private const string packOutputCopy = "../../nuget";
        private const string envVarMissing = " environment variable is missing. Aborting.";

        private static class Targets
        {
            public const string CleanBuildOutput = "clean-build-output";
            public const string CleanPackOutput = "clean-pack-output";
            public const string Build = "build";
            public const string Test = "test";
            public const string Pack = "pack";
            public const string SignBinary = "sign-binary";
            public const string SignPackage = "sign-package";
            public const string CopyPackOutput = "copy-pack-output";
        }

        static async Task Main(string[] args)
        {
            if (args.Length >= 0)
            {
                Console.WriteLine(args);
            }

            Target(Targets.CleanBuildOutput, () =>
            {
                Run("dotnet", $"clean {solution} -c Release -v m --nologo");
            });

            Target(Targets.Build, DependsOn(Targets.CleanBuildOutput), () =>
            {
                Run("dotnet", $"build {solution} -c Release --nologo");
            });

            Target(Targets.SignBinary, DependsOn(Targets.Build), () =>
            {
                Sign("./src/bin/Release", "*.dll");
            });

            Target(Targets.Test, DependsOn(Targets.Build), () =>
            {
                Run("dotnet", $"test {solution} -c Release --no-build");
            });

            Target(Targets.CleanPackOutput, () =>
            {
                if (Directory.Exists(packOutput))
                {
                    Directory.Delete(packOutput, true);
                }
            });

            Target(Targets.Pack, DependsOn(Targets.Build, Targets.CleanPackOutput), () =>
            {
                var directory = Directory.CreateDirectory(packOutput).FullName;
                Run("dotnet", $"pack ./src/Storage/Jaryway.IdentityServer.Storage.csproj -c Release -o {directory} --no-build --nologo");
                Run("dotnet", $"pack ./src/IdentityServer/Jaryway.IdentityServer.csproj -c Release -o {directory} --no-build --nologo");
                Run("dotnet", $"pack ./src/EntityFramework.Storage/Jaryway.IdentityServer.EntityFramework.Storage.csproj -c Release -o {directory} --no-build --nologo");
                Run("dotnet", $"pack ./src/EntityFramework/Jaryway.IdentityServer.EntityFramework.csproj -c Release -o {directory} --no-build --nologo");
                Run("dotnet", $"pack ./src/AspNetIdentity/Jaryway.IdentityServer.AspNetIdentity.csproj -c Release -o {directory} --no-build --nologo");
            });

            Target(Targets.SignPackage, DependsOn(Targets.Pack), () =>
            {
                Sign(packOutput, "*.nupkg");
            });

            Target(Targets.CopyPackOutput, DependsOn(Targets.Pack), () =>
            {
                Directory.CreateDirectory(packOutputCopy);

                foreach (var file in Directory.GetFiles(packOutput))
                {
                    File.Copy(file, Path.Combine(packOutputCopy, Path.GetFileName(file)), true);
                }
            });

            Target("default", DependsOn(Targets.Test, Targets.CopyPackOutput));

            Target("sign", DependsOn(Targets.SignBinary, Targets.Test, Targets.SignPackage, Targets.CopyPackOutput));

            await RunTargetsAndExitAsync(args, ex => ex is SimpleExec.ExitCodeException || ex.Message.EndsWith(envVarMissing));
        }

        private static void Sign(string path, string searchTerm)
        {
            var signClientSecret = Environment.GetEnvironmentVariable("SignClientSecret");

            if (string.IsNullOrWhiteSpace(signClientSecret))
            {
                throw new Exception($"SignClientSecret{envVarMissing}");
            }

            foreach (var file in Directory.GetFiles(path, searchTerm, SearchOption.AllDirectories))
            {
                Console.WriteLine($"  Signing {file}");
                Run("dotnet", $"SignClient sign -c ../../signClient.json -i {file} -r sc-ids@dotnetfoundation.org -s \"{signClientSecret}\" -n 'IdentityServer4'", noEcho: true);
            }
        }
    }
}
