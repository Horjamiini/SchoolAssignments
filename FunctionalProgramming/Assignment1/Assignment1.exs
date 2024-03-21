##Part1
var1 = 123
IO.puts(var1)

ask = IO.gets("What do you wanna say?")
var2 = "<- You said that"
var3 = #{ask} #{var2}
IO.puts(var3)

##Part2
calc1 = 154/78
IO.puts(calc1)

calc2 = ceil(calc1)
IO.puts(calc2)

calc3 = div(154,78)
IO.puts(calc3)

##Part3
ask2 = IO.gets("Tell me something\n")

var4 = String.length(ask2)
IO.puts(var4)

var5 = String.reverse(ask2)
IO.puts(var5)

var6 = replace(ask2,"foo","bar")
IO.puts(var6)

##Part4
anonym = fn a, b, c -> a * b * c end
number1 = IO.gets("Give me first number\n")
number1 = String.trim(number1)
number1 = String.to_integer(number1)
number2 = IO.gets("Give me second number\n")
number2 = String.trim(number2)
number2 = String.to_integer(number2)
number3 = IO.gets("Give me third number\n")
number3 = String.trim(number3)
number3 = String.to_integer(number3)
IO.puts = (anonym.(number1,number2,number3))

lists = fn a, b -> a ++ b end
IO.puts(lists.([1,2,3],[4,5,6]))

tuple = {:ok, :fail}
newtuple = Tuple.append(tuple,:canceled)
IO.puts(newtuple)
