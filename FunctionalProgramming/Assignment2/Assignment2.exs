##Part1
sentence = "99 bottles of beer on the wall"
sentence = String.split(sentence)
IO.puts(Enum.count(sentence))

##Part2

#Task two
defmodule Example do
  @vowels ~w[a e i o u ]
  @vowelish ["x", "y"]
  @qu ["q", "u"]

# "Pattern Matching with Elixir. Remember that equals sign is a match operator, not an assignment"


  def piglatin(lause) do
    lause
      |> String.split()
      |> Enum.map(&String.graphemes/1)
      |> Enum.map(&translation(&1))
      |> Enum.join(" ")

  end

  def translation([first | remaining]) when first in @vowels do
    ([first | remaining] ++ ["a", "y"])
    |> Enum.join()
  end
  def translation([first, second | remaining])
      when first in @vowelish and second == "t" or "r" do
    ([first, second | remaining] ++ ["a", "y"])
    |> Enum.join()
  end
  def translation([first, second | remaining]) when [first, second] == @qu do
    translation(remaining ++ [first, second])
  end
  def translation(letters) do
    if (@vowels ++ @vowelish) -- letters == @vowelish do
      (letters ++ ["a", "y"])
      |> Enum.join()
    else
      translation(Enum.slice(letters, 1..-1) ++ Enum.slice(letters, 0..0))
    end
  end

end

IO.inspect(Example.piglatin("Pattern Matching with Elixir. Remember that equals sign is a match operator, not an assignment"))
