// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Roslynator",
    "RCS1163",
    Justification = "The InitializeClass constructor needs to have TestContext injected to it or else Visual Studio cannot detect the project's tests"
)]
