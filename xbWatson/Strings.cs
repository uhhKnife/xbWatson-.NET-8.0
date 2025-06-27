using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace xbWatson
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[CompilerGenerated]
	internal class Strings
	{
		internal Strings()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Strings.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("xbWatson.Strings", typeof(Strings).Assembly);
					Strings.resourceMan = resourceManager;
				}
				return Strings.resourceMan!;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Strings.resourceCulture!;
			}
			set
			{
				Strings.resourceCulture = value;
			}
		}

		internal static string BreakButtonText
		{
			get
			{
				return Strings.ResourceManager.GetString("BreakButtonText", Strings.resourceCulture)!;
			}
		}

		internal static string ChangesSaveError
		{
			get
			{
				return Strings.ResourceManager.GetString("ChangesSaveError", Strings.resourceCulture)!;
			}
		}

		internal static string ConsoleConnectionError
		{
			get
			{
				return Strings.ResourceManager.GetString("ConsoleConnectionError", Strings.resourceCulture)!;
			}
		}

		internal static string ConsoleEntryRequest
		{
			get
			{
				return Strings.ResourceManager.GetString("ConsoleEntryRequest", Strings.resourceCulture)!;
			}
		}

		internal static string ConsoleNotAvailable
		{
			get
			{
				return Strings.ResourceManager.GetString("ConsoleNotAvailable", Strings.resourceCulture)!;
			}
		}

		internal static string ConsolePresentError
		{
			get
			{
				return Strings.ResourceManager.GetString("ConsolePresentError", Strings.resourceCulture)!;
			}
		}

		internal static string ConsoleSelectRequest
		{
			get
			{
				return Strings.ResourceManager.GetString("ConsoleSelectRequest", Strings.resourceCulture)!;
			}
		}

		internal static string DefaultXenonAbsent
		{
			get
			{
				return Strings.ResourceManager.GetString("DefaultXenonAbsent", Strings.resourceCulture)!;
			}
		}

		internal static string DisconnectConfirmation
		{
			get
			{
				return Strings.ResourceManager.GetString("DisconnectConfirmation", Strings.resourceCulture)!;
			}
		}

		internal static string PathEntryRequest
		{
			get
			{
				return Strings.ResourceManager.GetString("PathEntryRequest", Strings.resourceCulture)!;
			}
		}

		internal static string RegistrCreationError
		{
			get
			{
				return Strings.ResourceManager.GetString("RegistrCreationError", Strings.resourceCulture)!;
			}
		}

		internal static string RegistryAccessError
		{
			get
			{
				return Strings.ResourceManager.GetString("RegistryAccessError", Strings.resourceCulture)!;
			}
		}

		internal static string SaveCrashDumpButtonText
		{
			get
			{
				return Strings.ResourceManager.GetString("SaveCrashDumpButtonText", Strings.resourceCulture)!;
			}
		}

		internal static string Version
		{
			get
			{
				return Strings.ResourceManager.GetString("Version", Strings.resourceCulture)!;
			}
		}

		private static ResourceManager? resourceMan;

		private static CultureInfo? resourceCulture;
	}
}