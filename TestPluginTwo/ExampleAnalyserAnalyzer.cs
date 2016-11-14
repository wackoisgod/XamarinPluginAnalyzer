using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace TestPluginTwo
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class ExampleAnalyserAnalyzer : DiagnosticAnalyzer
	{
		public const string DiagnosticId = "ExampleAnalyser";
		private const string Category = "Naming";
		private static readonly LocalizableString Title
			= "Type name contains lowercase letters";
		private static readonly LocalizableString MessageFormat
			= "Type name '{0}' contains lowercase letters";
		private static readonly LocalizableString Description
			= "Type names should be all uppercase.";

		private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(
			DiagnosticId,
			Title,
			MessageFormat,
			Category,
			DiagnosticSeverity.Warning,
			isEnabledByDefault: true,
			description: Description
		);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
		{
			get { return ImmutableArray.Create(Rule); }
		}

		public override void Initialize(AnalysisContext context)
		{
			context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
		}

		private static void AnalyzeSymbol(SymbolAnalysisContext context)
		{
			var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
			if (namedTypeSymbol.Name.ToCharArray().Any(char.IsLower))
			{
				context.ReportDiagnostic(Diagnostic.Create(
					Rule,
					namedTypeSymbol.Locations[0],
					namedTypeSymbol.Name
				));
			}
		}
	}
}
