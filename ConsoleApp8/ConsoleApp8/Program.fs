// Задание 3: Вариант - 9
open System;
open System.IO

// Запись всех имён файлов в последовательность
let rec Files_Name (way: string): seq<string> =
    seq {
            yield! Directory.EnumerateFiles(way)
            for i in Directory.GetDirectories(way) do
                yield! Files_Name i
    }

// Проверка на корректность введённого символа
let rec Check_Symbol() =
    let input = Console.ReadLine()
    if String.IsNullOrEmpty(input) then
        printfn "Ошибка: Введено пустое значение. Введите один символ: "
        Check_Symbol()
    else
        input.[0]  // Возвращаем первый символ

[<EntryPoint>]
let main args = 
    printfn "Введите путь к каталогу: "
    let way = Console.ReadLine()
    let Files = Files_Name way
    printfn "Введите символ: "
    let symbol = Check_Symbol()
    let count = 
        Files
        |> Seq.filter (fun file -> Path.GetFileName(file).StartsWith(symbol.ToString()))
        |> Seq.length 

    printfn "Количество файлов, начинающихся с символа: %i" count
    0

