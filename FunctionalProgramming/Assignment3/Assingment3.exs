## Task1
number = IO.gets("Give me a number: ")
number = String.trim(number)
number = String.to_integer(number)
cond do
  rem(number,3) == 0 -> IO.puts "Divisible by 3"
  rem(number,5) == 0 -> IO.puts "Divisible by 5"
  rem(number,7) == 0 -> IO.puts "Divisible by 7"
  rem(number,2) == 0 -> IO.puts "Divisible by 2"
  rem(number,4) == 0 -> IO.puts "Divisible by 4"
  rem(number,6) == 0 -> IO.puts "Divisible by 6"
  rem(number,8) == 0 -> IO.puts "Divisible by 8"
  rem(number,9) == 0 -> IO.puts "Divisible by 9"
  true -> IO.puts "This number is not evenly divisible!"
end


## Task 2
func = fn
  x, y when is_binary(x) and is_binary(y) -> x <> y
  x, y -> x + y
end

IO.puts func.("Hyvaa", "huomenta")
IO.puts func.(2, 5)
