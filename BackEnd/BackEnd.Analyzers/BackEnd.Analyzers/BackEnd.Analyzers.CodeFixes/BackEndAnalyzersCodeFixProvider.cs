using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;

namespace BackEnd.Analyzers;

[ExportCodeFixProvider(
    LanguageNames.CSharp,
    Name = nameof(BackEndAnalyzersCodeFixProvider))]
[Shared]
public sealed class BackEndAnalyzersCodeFixProvider : CodeFixProvider
{
    public override ImmutableArray<string> FixableDiagnosticIds =>  [];

    public override FixAllProvider GetFixAllProvider() => null;

    public override Task RegisterCodeFixesAsync(CodeFixContext context) => Task.CompletedTask;
}