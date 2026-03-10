// Задание 1: Вариант - 9
open System;

// Проверка числа на корректность
let rec Check_quantity() =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)
    if succes then
       n
    else
        printfn "Ошибка: Введенное значение должно быть целым числом. Введите другое значение: "
        Check_quantity()

// Создание исходной последовательности
let Create_Seq quantity =
    seq {
            for i in 1..quantity do
                printfn "Введите число %i: " i
                let number = Check_quantity()
                yield number    
    }

[<EntryPoint>]
let main args = 
    printfn "Введите количество чисел, входящих в исходную последовательность: "
    let quantity = Check_quantity()
    let seq_1 = Create_Seq quantity |> Seq.cache
    printfn "Исходная последовательность: %A" seq_1
    let seq_2 = Seq.map (fun i -> i%2 = 0) seq_1
    printf "Новая последовательность: %A" seq_2
    0