﻿using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Patchwork.Attributes;

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("03f1fae8-17bb-4c76-9665-cad79916a0ad")]
[assembly: PatchAssembly]
[assembly: AssemblyTitle("Patchwork.Attributes")]
[assembly: AssemblyDescription("")]
[assembly: InternalsVisibleTo("Patchwork")]
namespace Patchwork.Shared {
	/// <summary>
	/// Provides version information for Patchwork and its related assemblies.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	
	[NewType(true)] //although this is an explicit member, we want to make it behave like an explicit one.
	public static class PwVersion {
		public const string Version = "0.5.0.2";
	}
}
