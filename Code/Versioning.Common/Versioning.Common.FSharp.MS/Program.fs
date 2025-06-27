open System
open System.Reflection

[<EntryPoint>]
let main _ =
    // Get the current assembly version
    let assembly = Assembly.GetExecutingAssembly()
    let version = assembly.GetName().Version
    printfn "Current Version: %O" version

    // Wait for user input before closing
    printfn "Press any key to exit..."
    Console.ReadKey() |> ignore
    0
