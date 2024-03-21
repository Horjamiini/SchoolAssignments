Code.require_file("calculator.ex")

defmodule Loop do
  def questions do
    input_calc = String.trim(IO.gets("What would you like to calculate? (example 123+456): "))
    Calculator.calc(input_calc)
    questions()
  end

end

Loop.questions()
