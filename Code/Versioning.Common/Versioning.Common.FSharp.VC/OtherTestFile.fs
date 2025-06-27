namespace Versioning

open System.Reflection

module OtherTestFile =
    let printAssemblyVersion () =
        let assembly = Assembly.GetExecutingAssembly()
        let version = assembly.GetName().Version
        printfn "Current Version: %O" version
