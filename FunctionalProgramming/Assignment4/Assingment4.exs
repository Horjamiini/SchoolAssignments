## Task1

defmodule Colorfinder do
  def color_find(colorlist) do
    color = String.trim(IO.gets("Give me a color name or color html code: "))
    color_find(colorlist, color)
  end

  def color_find(colorlist,color) do
    cond do
      Keyword.has_key?(colorlist, String.to_atom(color)) ->
        IO.puts(color <> " html color value is: " <> Keyword.get(colorlist, String.to_atom(color)))
        color_find(colorlist)
      String.contains?(color, "#") ->
        {color, _} = Enum.find(colorlist, fn tuple -> String.equivalent?(elem(tuple, 1), color) == true end)
        IO.puts(color)
        color_find(colorlist)
      true -> IO.puts("Invalid output, exiting...")
    end
  end
end


colorlist = [
  {:azure, "#F0FFF"},
  {:coral, "#FF75F50"},
  {:deeppink,"#FF1493"},
  {:forestgreen, "#228B22"},
  {:lemonchiffon, "#FFFACD"},
  {:navy, "#000080"},
  {:sienna ,"#A0522D"},
  {:silver, "#C0C0C0"},
  {:thistle, "#D8BFD8"},
  {:yellow, "#FFFF00"}]

Colorfinder.color_q(colorlist)


# Task2
defmodule Bookfinder do
  def book_finder(booklist) do
    IO.puts("What would you like to do?: \n ")
    IO.puts("List all books - 1 \n Search book by ISBN - 2 \n Add new book - 3 \n Remove book by ISBN - 4 \n Quit - 5 ")
    {answer, _} = IO.gets("Input your choice: ") |> Integer.parse
    answer_choice(booklist, answer)
  end

  def answer_choice(booklist, answer) do
    cond do
      answer == 1 -> list_books(booklist)
      answer == 2 -> search_book(booklist)
      answer == 3 -> add_book(booklist)
      answer == 4 -> remove_book(booklist)
      answer == 5 -> IO.puts("Thanks for using bookfinder!")
      true -> book_finder(booklist)
    end
  end

  defp list_books(booklist) do
    IO.puts("Books in list: \n")
    Enum.each(booklist, fn item -> IO.puts(elem(item, 1)) end)
    book_finder(booklist)
  end

  defp search_book(booklist) do
    isbn_answer = String.trim(IO.gets("ISBN: "))
    if Map.get(booklist, isbn_answer) do
      IO.puts("Book found: " <> Map.get(booklist, isbn_answer) <> "\n")
    else
      IO.puts("No matching book found")
    end
  book_finder(booklist)
  end

  defp add_book(booklist) do
    book_name = String.trim(IO.gets("Book name: "))
    book_isbn = String.trim(IO.gets("Book ISBN: "))
    books_new = Map.put(booklist, book_isbn, book_name)
    IO.puts("Book: " <> book_name <> " updated to the booklist")
    book_finder(books_new)
  end

  defp remove_book(booklist) do
    book_isbn = String.trim(IO.gets("Book ISBN: "))
    books_new = Map.delete(booklist, book_isbn)
    IO.puts("Book: " <> Map.get(booklist, book_isbn) <> " has been deleted from booklist")
    book_finder(books_new)
  end
end

booklist = %{"9789522154446" => "Seitseman veljesta", "9789510445785" => "Tuntematon sotilas",
"9789174296907" => "Shutter Island - Patient 67", "9789510489826" => "Mielensapahoittaja Eskorttia etsimässa",
"9780008402785" => "Fire and Blood"}

Bookfinder.book_finder(booklist)
