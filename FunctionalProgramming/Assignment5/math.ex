defmodule Math do

  def add(a,b) do
    text = "Adding"
    calculation = a + b
    info(text, a, b, calculation)
  end

  def sub(a,b) do
    text = "Subtracting"
    calculation = a - b
    info(text, a, b, calculation)
  end

  def mul(a,b) do
    text = "Multiplying"
    calculation = a * b
    info(text, a, b, calculation)
  end

  def div(a,b) do
    text = "Dividing"
    calculation = a / b
    info(text, a, b, calculation)
  end

  defp info(text, a, b, calculation) do
    IO.puts "#{text} #{a} and #{b} ... result is #{calculation}"
  end
end
