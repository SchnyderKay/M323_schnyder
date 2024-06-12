module FileReader 

open System
open System.IO

let readFile (filePath: string) : Result<string, string> =
    try
        if File.Exists(filePath) then
            let content = File.ReadAllText(filePath)
            Ok content
        else
            Error (sprintf "File not found: %s" filePath)
    with
    | :? UnauthorizedAccessException as ex ->
        Error (sprintf "Access denied to file: %s. Exception: %s" filePath ex.Message)
    | :? IOException as ex ->
        Error (sprintf "IO error reading file: %s. Exception: %s" filePath ex.Message)
    | ex ->
        Error (sprintf "Unexpected error reading file: %s. Exception: %s" filePath ex.Message)

    


