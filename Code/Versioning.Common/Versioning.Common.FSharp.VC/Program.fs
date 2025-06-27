open System
open Versioning.OtherTestFile

[<EntryPoint>]
let main _ =
    // Call the shared version printer
    printAssemblyVersion()

    // Wait for user input before closing
    printfn "Press any key to exit..."
    Console.ReadKey() |> ignore
    0
