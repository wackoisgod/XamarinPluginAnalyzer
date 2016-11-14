using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
	"TestPluginTwo",
	Namespace = "TestPluginTwo",
	Version = "1.0"
)]

[assembly: AddinName("TestPluginTwo")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("TestPluginTwo")]
[assembly: AddinAuthor("aspie")]
