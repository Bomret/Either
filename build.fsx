#r @"FAKE\tools\FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

RestorePackages()

let buildDir = "./build"
let testDir = "./test"
let testAssemblies = !! (testDir + "/*.Tests.dll")
let version = 
    match buildServer with
        | TeamCity -> buildVersion
        | _ -> "0.1.0"

Target "Clean" (fun _ -> CleanDirs [buildDir; testDir])

Target "BuildLib" (fun _ -> 
    CreateCSharpAssemblyInfo "./Either/Properties/AssemblyInfo.cs"
        [Attribute.Title "Either"
         Attribute.Description "A Either type that represents one of two types."
         Attribute.Guid "a043d66c-6d45-4038-84a4-6f6b8cf9384d"
         Attribute.Product "Either"
         Attribute.Version version
         Attribute.FileVersion version]

    !! "Either/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "Build output: "
)

Target "BuildTests" (fun _ -> 
    !! "Either.Tests/**/*.csproj"
    |> MSBuildDebug testDir "Build"
    |> Log "Test build output: "
)

Target "Test" (fun _ ->
    testAssemblies
        |> MSpec (fun p -> {p with HtmlOutputDir = testDir})
)

"Clean"
    ==> "BuildLib"
    ==> "BuildTests"
    ==> "Test"

RunTargetOrDefault "Test"