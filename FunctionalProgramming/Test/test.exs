defmodule Matcher do
  def match([head | rest]) do match(rest)
  end
  def match(last) do last
  end

end

Matcher.match([1,2,3])
