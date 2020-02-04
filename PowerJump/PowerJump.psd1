# https://msdn.microsoft.com/en-us/library/dd878337(v=vs.85).aspx

@{

# Script module or binary module file associated with this manifest
RootModule = 'PowerJump.dll'

# Version number of this module.
ModuleVersion = '0.3'

# ID used to uniquely identify this module
GUID = 'c732c504-4f78-4311-8023-1ec0dd92cd7b'

# Author of this module
Author = 'kjerk@kjerk.dev'

# Description of the functionality provided by this module
Description = 'A powershell module enabling bookmarking and quick jumping around the filesystem.'

# Minimum version of the Windows PowerShell engine required by this module
# PowerShellVersion = '5.0'

# Minimum version of the .NET Framework required by this module
# DotNetFrameworkVersion = '4.0'

# Functions to export from this module
FunctionsToExport = '*'

# Cmdlets to export from this module
CmdletsToExport = '*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = '*'

# Company or vendor of this module
#CompanyName = 'Unknown'

# Name of the Windows PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the Windows PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of the common language runtime (CLR) required by this module
# CLRVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
# RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
# RequiredAssemblies = @()

# Script files (.ps1) that are run in the caller's environment prior to importing this module
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
# FormatsToProcess = @()

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
# NestedModules = @()

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess
# PrivateData = ''

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}

# Set-Alias jump Find-Jump # JumpCommand
# Set-Alias jumps List-Jumps # JumpCommand

# Set-Alias mark Add-Jump # AddCommand
# Set-Alias unmark Remove-Jump # RemoveCommand

# Set-Alias editjumps Edit-Jumps # EditCommand
# Set-Alias loadjumps Load-Jumps # LoadCommand
# Set-Alias savejumps Save-Jumps # SaveCommand
