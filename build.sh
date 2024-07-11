#!/usr/bin/env bash
set -euo pipefail

dotnet run --project build -- "$@"

# pushd ./src/Storage
# ./build.sh "$@"
# popd

# pushd ./src/IdentityServer4
# ./build.sh "$@"
# popd

# pushd ./src/EntityFramework.Storage
# ./build.sh "$@"
# popd

# pushd ./src/EntityFramework
# ./build.sh "$@"
# popd

# pushd ./src/AspNetIdentity
# ./build.sh "$@"
# popd
