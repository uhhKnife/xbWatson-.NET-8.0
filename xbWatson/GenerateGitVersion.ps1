$hash = git rev-parse --short HEAD
$content = @"
namespace xbWatson {
    public static class GitVersion {
        public const string Commit = "$hash";
    }
}
"@
Set-Content -Path "$PSScriptRoot\GitVersion.g.cs" -Value $content -Encoding UTF8
