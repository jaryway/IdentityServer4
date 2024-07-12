// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using Jaryway.IdentityServer.Models;
using System;
using System.Collections.Generic;

namespace Jaryway.IdentityServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 
        /// </summary>
        public const string IdentityServerName = "IdentityServer4";
        /// <summary>
        /// 
        /// </summary>
        public const string IdentityServerAuthenticationType = IdentityServerName;
        /// <summary>
        /// 
        /// </summary>
        public const string ExternalAuthenticationMethod = "external";
        /// <summary>
        /// 
        /// </summary>
        public const string DefaultHashAlgorithm = "SHA256";
        /// <summary>
        /// 
        /// </summary>
        public static readonly TimeSpan DefaultCookieTimeSpan = TimeSpan.FromHours(10);
        /// <summary>
        /// 
        /// </summary>
        public static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromMinutes(60);
        /// <summary>
        /// 
        /// </summary>
        public static readonly List<string> SupportedResponseTypes = new List<string>
        {
            OidcConstants.ResponseTypes.Code,
            OidcConstants.ResponseTypes.Token,
            OidcConstants.ResponseTypes.IdToken,
            OidcConstants.ResponseTypes.IdTokenToken,
            OidcConstants.ResponseTypes.CodeIdToken,
            OidcConstants.ResponseTypes.CodeToken,
            OidcConstants.ResponseTypes.CodeIdTokenToken
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly Dictionary<string, string> ResponseTypeToGrantTypeMapping = new Dictionary<string, string>
        {
            { OidcConstants.ResponseTypes.Code, GrantType.AuthorizationCode },
            { OidcConstants.ResponseTypes.Token, GrantType.Implicit },
            { OidcConstants.ResponseTypes.IdToken, GrantType.Implicit },
            { OidcConstants.ResponseTypes.IdTokenToken, GrantType.Implicit },
            { OidcConstants.ResponseTypes.CodeIdToken, GrantType.Hybrid },
            { OidcConstants.ResponseTypes.CodeToken, GrantType.Hybrid },
            { OidcConstants.ResponseTypes.CodeIdTokenToken, GrantType.Hybrid }
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly List<string> AllowedGrantTypesForAuthorizeEndpoint = new List<string>
        {
            GrantType.AuthorizationCode,
            GrantType.Implicit,
            GrantType.Hybrid
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly List<string> SupportedCodeChallengeMethods = new List<string>
        {
            OidcConstants.CodeChallengeMethods.Plain,
            OidcConstants.CodeChallengeMethods.Sha256
        };
        /// <summary>
        /// 
        /// </summary>
        public enum ScopeRequirement
        {
            /// <summary>
            /// 
            /// </summary>
            None,
            /// <summary>
            /// 
            /// </summary>
            ResourceOnly,
            /// <summary>
            /// 
            /// </summary>
            IdentityOnly,
            /// <summary>
            /// 
            /// </summary>
            Identity
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly Dictionary<string, ScopeRequirement> ResponseTypeToScopeRequirement = new Dictionary<string, ScopeRequirement>
        {
            { OidcConstants.ResponseTypes.Code, ScopeRequirement.None },
            { OidcConstants.ResponseTypes.Token, ScopeRequirement.ResourceOnly },
            { OidcConstants.ResponseTypes.IdToken, ScopeRequirement.IdentityOnly },
            { OidcConstants.ResponseTypes.IdTokenToken, ScopeRequirement.Identity },
            { OidcConstants.ResponseTypes.CodeIdToken, ScopeRequirement.Identity },
            { OidcConstants.ResponseTypes.CodeToken, ScopeRequirement.Identity },
            { OidcConstants.ResponseTypes.CodeIdTokenToken, ScopeRequirement.Identity }
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly Dictionary<string, IEnumerable<string>> AllowedResponseModesForGrantType = new Dictionary<string, IEnumerable<string>>
        {
            { GrantType.AuthorizationCode, new[] { OidcConstants.ResponseModes.Query, OidcConstants.ResponseModes.FormPost, OidcConstants.ResponseModes.Fragment } },
            { GrantType.Hybrid, new[] { OidcConstants.ResponseModes.Fragment, OidcConstants.ResponseModes.FormPost }},
            { GrantType.Implicit, new[] { OidcConstants.ResponseModes.Fragment, OidcConstants.ResponseModes.FormPost }}
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly List<string> SupportedResponseModes = new List<string>
        {
            OidcConstants.ResponseModes.FormPost,
            OidcConstants.ResponseModes.Query,
            OidcConstants.ResponseModes.Fragment
        };
        /// <summary>
        /// 
        /// </summary>
        public static string[] SupportedSubjectTypes =
        {
            "pairwise", "public"
        };
        /// <summary>
        /// 
        /// </summary>
        public static class SigningAlgorithms
        {
            /// <summary>
            /// 
            /// </summary>
            public const string RSA_SHA_256 = "RS256";
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly List<string> SupportedDisplayModes = new List<string>
        {
            OidcConstants.DisplayModes.Page,
            OidcConstants.DisplayModes.Popup,
            OidcConstants.DisplayModes.Touch,
            OidcConstants.DisplayModes.Wap
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly List<string> SupportedPromptModes = new List<string>
        {
            OidcConstants.PromptModes.None,
            OidcConstants.PromptModes.Login,
            OidcConstants.PromptModes.Consent,
            OidcConstants.PromptModes.SelectAccount
        };
        /// <summary>
        /// 
        /// </summary>
        public static class KnownAcrValues
        { /// <summary>
          /// 
          /// </summary>
            public const string HomeRealm = "idp:";
            /// <summary>
            /// 
            /// </summary>
            public const string Tenant = "tenant:";
            /// <summary>
            /// 
            /// </summary>
            public static readonly string[] All = { HomeRealm, Tenant };
        }
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, int> ProtectedResourceErrorStatusCodes = new Dictionary<string, int>
        {
            { OidcConstants.ProtectedResourceErrors.InvalidToken,      401 },
            { OidcConstants.ProtectedResourceErrors.ExpiredToken,      401 },
            { OidcConstants.ProtectedResourceErrors.InvalidRequest,    400 },
            { OidcConstants.ProtectedResourceErrors.InsufficientScope, 403 }
        };
        /// <summary>
        /// 
        /// </summary>
        public static readonly Dictionary<string, IEnumerable<string>> ScopeToClaimsMapping = new Dictionary<string, IEnumerable<string>>
        {
            { IdentityServerConstants.StandardScopes.Profile, new[]
                            {
                                JwtClaimTypes.Name,
                                JwtClaimTypes.FamilyName,
                                JwtClaimTypes.GivenName,
                                JwtClaimTypes.MiddleName,
                                JwtClaimTypes.NickName,
                                JwtClaimTypes.PreferredUserName,
                                JwtClaimTypes.Profile,
                                JwtClaimTypes.Picture,
                                JwtClaimTypes.WebSite,
                                JwtClaimTypes.Gender,
                                JwtClaimTypes.BirthDate,
                                JwtClaimTypes.ZoneInfo,
                                JwtClaimTypes.Locale,
                                JwtClaimTypes.UpdatedAt
                            }},
            { IdentityServerConstants.StandardScopes.Email, new[]
                            {
                                JwtClaimTypes.Email,
                                JwtClaimTypes.EmailVerified
                            }},
            { IdentityServerConstants.StandardScopes.Address, new[]
                            {
                                JwtClaimTypes.Address
                            }},
            { IdentityServerConstants.StandardScopes.Phone, new[]
                            {
                                JwtClaimTypes.PhoneNumber,
                                JwtClaimTypes.PhoneNumberVerified
                            }},
            { IdentityServerConstants.StandardScopes.OpenId, new[]
                            {
                                JwtClaimTypes.Subject
                            }}
        };
        /// <summary>
        /// 
        /// </summary>
        public static class UIConstants
        {
            // the limit after which old messages are purged
            /// <summary>
            /// 
            /// </summary>
            public const int CookieMessageThreshold = 2;
            /// <summary>
            /// 
            /// </summary>
            public static class DefaultRoutePathParams
            { /// <summary>
              /// 
              /// </summary>
                public const string Error = "errorId";
                /// <summary>
                /// 
                /// </summary>
                public const string Login = "returnUrl";
                /// <summary>
                /// 
                /// </summary>
                public const string Consent = "returnUrl";
                /// <summary>
                /// 
                /// </summary>
                public const string Logout = "logoutId";
                /// <summary>
                /// 
                /// </summary>
                public const string EndSessionCallback = "endSessionId";
                /// <summary>
                /// 
                /// </summary>
                public const string Custom = "returnUrl";
                /// <summary>
                /// 
                /// </summary>
                public const string UserCode = "userCode";
            }
            /// <summary>
            /// 
            /// </summary>
            public static class DefaultRoutePaths
            {
                /// <summary>
                /// 
                /// </summary>
                public const string Login = "/account/login";
                /// <summary>
                /// 
                /// </summary>
                public const string Logout = "/account/logout";
                /// <summary>
                /// 
                /// </summary>
                public const string Consent = "/consent";
                /// <summary>
                /// 
                /// </summary>
                public const string Error = "/home/error";
                /// <summary>
                /// 
                /// </summary>
                public const string DeviceVerification = "/device";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static class EndpointNames
        {
            /// <summary>
            /// 
            /// </summary>
            public const string Authorize = "Authorize";
            /// <summary>
            /// 
            /// </summary>
            public const string Token = "Token";
            /// <summary>
            /// 
            /// </summary>
            public const string DeviceAuthorization = "DeviceAuthorization";
            /// <summary>
            /// 
            /// </summary>
            public const string Discovery = "Discovery";
            /// <summary>
            /// 
            /// </summary>
            public const string Introspection = "Introspection";
            /// <summary>
            /// 
            /// </summary>
            public const string Revocation = "Revocation";
            /// <summary>
            /// 
            /// </summary>
            public const string EndSession = "Endsession";
            /// <summary>
            /// 
            /// </summary>
            public const string CheckSession = "Checksession";
            /// <summary>
            /// 
            /// </summary>
            public const string UserInfo = "Userinfo";
        }
        /// <summary>
        /// 
        /// </summary>
        public static class ProtocolRoutePaths
        {
            /// <summary>
            /// 
            /// </summary>
            public const string ConnectPathPrefix = "connect";
            /// <summary>
            /// 
            /// </summary>
            public const string Authorize = ConnectPathPrefix + "/authorize";
            /// <summary>
            /// 
            /// </summary>
            public const string AuthorizeCallback = Authorize + "/callback";
            /// <summary>
            /// 
            /// </summary>
            public const string DiscoveryConfiguration = ".well-known/openid-configuration";
            /// <summary>
            /// 
            /// </summary>
            public const string DiscoveryWebKeys = DiscoveryConfiguration + "/jwks";
            /// <summary>
            /// 
            /// </summary>
            public const string Token = ConnectPathPrefix + "/token";
            /// <summary>
            /// 
            /// </summary>
            public const string Revocation = ConnectPathPrefix + "/revocation";
            /// <summary>
            /// 
            /// </summary>
            public const string UserInfo = ConnectPathPrefix + "/userinfo";
            /// <summary>
            /// 
            /// </summary>
            public const string Introspection = ConnectPathPrefix + "/introspect";
            /// <summary>
            /// 
            /// </summary>
            public const string EndSession = ConnectPathPrefix + "/endsession";
            /// <summary>
            /// 
            /// </summary>
            public const string EndSessionCallback = EndSession + "/callback";
            /// <summary>
            /// 
            /// </summary>
            public const string CheckSession = ConnectPathPrefix + "/checksession";
            /// <summary>
            /// 
            /// </summary>
            public const string DeviceAuthorization = ConnectPathPrefix + "/deviceauthorization";
            /// <summary>
            /// 
            /// </summary>
            public const string MtlsPathPrefix = ConnectPathPrefix + "/mtls";
            /// <summary>
            /// 
            /// </summary>
            public const string MtlsToken = MtlsPathPrefix + "/token";
            /// <summary>
            /// 
            /// </summary>
            public const string MtlsRevocation = MtlsPathPrefix + "/revocation";
            /// <summary>
            /// 
            /// </summary>
            public const string MtlsIntrospection = MtlsPathPrefix + "/introspect";
            /// <summary>
            /// 
            /// </summary>
            public const string MtlsDeviceAuthorization = MtlsPathPrefix + "/deviceauthorization";
            /// <summary>
            /// 
            /// </summary>
            public static readonly string[] CorsPaths =
            {
                DiscoveryConfiguration,
                DiscoveryWebKeys,
                Token,
                UserInfo,
                Revocation
            };
        }
        /// <summary>
        /// 
        /// </summary>
        public static class EnvironmentKeys
        {
            /// <summary>
            /// 
            /// </summary>
            public const string IdentityServerBasePath = "idsvr:IdentityServerBasePath";
            /// <summary>
            /// 
            /// </summary>
            [Obsolete("The IdentityServerOrigin constant is obsolete.")]
            public const string IdentityServerOrigin = "idsvr:IdentityServerOrigin"; // todo: deprecate
            /// <summary>
            /// 
            /// </summary>
            public const string SignOutCalled = "idsvr:IdentityServerSignOutCalled";
        }
        /// <summary>
        /// 
        /// </summary>
        public static class TokenTypeHints
        {
            /// <summary>
            /// 
            /// </summary>
            public const string RefreshToken = "refresh_token";
            /// <summary>
            /// 
            /// </summary>
            public const string AccessToken = "access_token";
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<string> SupportedTokenTypeHints = new List<string>
        {
            TokenTypeHints.RefreshToken,
            TokenTypeHints.AccessToken
        };
        /// <summary>
        /// 
        /// </summary>
        public static class RevocationErrors
        {
            /// <summary>
            /// 
            /// </summary>
            public const string UnsupportedTokenType = "unsupported_token_type";
        }
        /// <summary>
        /// 
        /// </summary>
        public class Filters
        {
            /// <summary>
            /// 
            /// </summary>
            // filter for claims from an incoming access token (e.g. used at the user profile endpoint)
            public static readonly string[] ProtocolClaimsFilter = {
                JwtClaimTypes.AccessTokenHash,
                JwtClaimTypes.Audience,
                JwtClaimTypes.AuthorizedParty,
                JwtClaimTypes.AuthorizationCodeHash,
                JwtClaimTypes.ClientId,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.JwtId,
                JwtClaimTypes.Nonce,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.ReferenceTokenId,
                JwtClaimTypes.SessionId,
                JwtClaimTypes.Scope
            };
            /// <summary>
            /// 
            /// </summary>
            // filter list for claims returned from profile service prior to creating tokens
            public static readonly string[] ClaimsServiceFilterClaimTypes = {
                // TODO: consider JwtClaimTypes.AuthenticationContextClassReference,
                JwtClaimTypes.AccessTokenHash,
                JwtClaimTypes.Audience,
                JwtClaimTypes.AuthenticationMethod,
                JwtClaimTypes.AuthenticationTime,
                JwtClaimTypes.AuthorizedParty,
                JwtClaimTypes.AuthorizationCodeHash,
                JwtClaimTypes.ClientId,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IdentityProvider,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.JwtId,
                JwtClaimTypes.Nonce,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.ReferenceTokenId,
                JwtClaimTypes.SessionId,
                JwtClaimTypes.Subject,
                JwtClaimTypes.Scope,
                JwtClaimTypes.Confirmation
            };
            /// <summary>
            /// 
            /// </summary>
            public static readonly string[] JwtRequestClaimTypesFilter = {
                JwtClaimTypes.Audience,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.JwtId
            };
        }
        /// <summary>
        /// 
        /// </summary>
        public static class WsFedSignOut
        {
            /// <summary>
            /// 
            /// </summary>
            public const string LogoutUriParameterName = "wa";
            /// <summary>
            /// 
            /// </summary>
            public const string LogoutUriParameterValue = "wsignoutcleanup1.0";
        }
        /// <summary>
        /// 
        /// </summary>
        public static class AuthorizationParamsStore
        {
            /// <summary>
            /// 
            /// </summary>
            public const string MessageStoreIdParameterName = "authzId";
        }
        /// <summary>
        /// 
        /// </summary>
        public static class CurveOids
        { /// <summary>
          /// 
          /// </summary>
            public const string P256 = "1.2.840.10045.3.1.7";
            /// <summary>
            /// 
            /// </summary>
            public const string P384 = "1.3.132.0.34";
            /// <summary>
            /// 
            /// </summary>
            public const string P521 = "1.3.132.0.35";
        }
    }
}