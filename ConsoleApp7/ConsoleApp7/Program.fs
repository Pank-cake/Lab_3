// Задание 2: Вариант - 9
open System;

// Проверка числа на корректность
let rec Check_quantity() =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)
    if succes && n >= 0 then
       n
    else
        printfn "Ошибка: Введенное значение должно быть натуральным числом. Введите другое значение: "
        Check_quantity()

// Проверка на корректность введённого значения
let rec CheckFigure() =
    let input = Console.ReadLine()
    match input with
    | "I" | "II" | "III" | "IV" | "V"
    | "VI" | "VII" | "VIII" | "IX" -> input
    | _ ->
        printfn "Ошибка: Введенное число должно быть римской цифрой. Введите другое значение: "
        CheckFigure()

// Создание последовательности римских цифр
let Create_Seq quantity =
    seq {
        for i in 1..quantity do
            printfn "Введите римскую цифру %i:" i
            yield CheckFigure()
    }

// Перевод римских цифр в арабские
let ReWrite seq_1 =
    Seq.map (fun i ->
        match i with
        | "I" -> 1
        | "II" -> 2
        | "III" -> 3
        | "IV" -> 4
        | "V" -> 5
        | "VI" -> 6
        | "VII" -> 7
        | "VIII" -> 8
        | "IX" -> 9
        | _ -> 0
    ) seq_1

[<EntryPoint>]
let main args = 
    printfn "Введите количество чисел, входящих в исходную последовательность: "
    let quantity = Check_quantity()
    let seq_1 = Create_Seq quantity |> Seq.cache
    printfn "Исходная последовательность: %A" seq_1
    let seq_2 = ReWrite seq_1
    let sum = Seq.fold (fun acc (sum) -> acc + sum) 0 seq_2
    printfn "Сумма элементов последовательности = %i" sum
    0