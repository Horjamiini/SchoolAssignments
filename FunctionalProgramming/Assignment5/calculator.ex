Code.require_file("math.ex")

defmodule Calculator do
  def calc(input) do
      [num1,num2] = String.split(String.trim(input), ["+","-","*","/"])
      cond do
      String.contains?(input, "+")
      -> Math.add(String.to_integer(num1),String.to_integer(num2))
      String.contains?(input, "-")
      -> Math.sub(String.to_integer(num1),String.to_integer(num2))
      String.contains?(input, "*")
      -> Math.mul(String.to_integer(num1),String.to_integer(num2))
      String.contains?(input, "/")
      -> Math.div(String.to_integer(num1),String.to_integer(num2))
      true -> IO.puts("Invalid output")
    end
  end
end
