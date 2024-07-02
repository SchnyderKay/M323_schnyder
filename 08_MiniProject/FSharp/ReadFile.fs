module FileReader 

open System
open System.IO

let readFile (filePath: string) : Result<string, string> =
    
    let file = filePath.Trim('"')

    try
        if File.Exists(file) then
            let content = File.ReadAllText(file)
            Ok content
        else
            Error (sprintf "File not found: %s" file)
    with
    | :? UnauthorizedAccessException as ex ->
        Error (sprintf "Access denied to file: %s. Exception: %s" file ex.Message)
    | :? IOException as ex ->
        Error (sprintf "IO error reading file: %s. Exception: %s" file ex.Message)
    | ex ->
        Error (sprintf "Unexpected error reading file: %s. Exception: %s" file ex.Message)

    


