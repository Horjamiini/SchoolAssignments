defmodule Blackjack do
  # draw cards
  def cards do
    Enum.random(1..11)
  end

  def dealer_draw(dealer,dealer_stay) do
    cond do
      Agent.get(dealer, fn state -> state end) < 17 ->
        Agent.update(dealer, fn state -> state + cards() end)

      true -> Agent.update(dealer_stay, fn state -> state + 1 end)
              IO.puts("\nDealer stays\n")
    end
  end

  def game_state(player,dealer) do
    player_state = Agent.get(player, fn state -> state end)
    dealer_state = Agent.get(dealer, fn state -> state end)
    IO.puts("Player hand: #{player_state} \nDealer  hand: #{dealer_state}")
  end

  def game_start do
    {:ok, player} = Agent.start_link fn -> 0 end
    {:ok, dealer} = Agent.start_link fn -> 0 end
    {:ok, player_stay} = Agent.start_link fn -> 0 end
    {:ok, dealer_stay} = Agent.start_link fn -> 0 end
    # game starts and both draw 2 cards
    Agent.update(player, fn state -> state + cards() + cards() end)
    Agent.update(dealer, fn state -> state + cards() + cards() end)

    game_state(player,dealer)

    main_game(player,dealer,player_stay,dealer_stay)
  end

  def main_game(player, dealer,player_stay,dealer_stay) do
    user_draw = String.trim(IO.gets("Do you want to draw? Y/N:?\n"))
    cond do
      user_draw == "n" ->
        dealer_draw(dealer,dealer_stay)
        Agent.update(player_stay, fn state -> state + 1 end)
        game_state(player,dealer)
        #Player is able to draw card after they have stayed,
        #in real blackjack this isn't possible

      user_draw == "y" ->
        Agent.update(player, fn state -> state + cards() end)
        dealer_draw(dealer,dealer_stay)
        game_state(player,dealer)

      true -> IO.puts("Something went wrong!/Invalid output!")
    end
    if (Agent.get(player_stay, fn state -> state end) >= 1 and
        Agent.get(dealer_stay, fn state -> state end) >= 1) or
        Agent.get(player, fn state -> state end) > 21 or
        Agent.get(dealer, fn state -> state end) > 21 do
          game_end(player,dealer)
    else
      main_game(player, dealer, player_stay, dealer_stay)
    end
  end

  def game_end(player,dealer) do
    player_end = Agent.get(player, fn state -> state end)
    dealer_end = Agent.get(dealer, fn state -> state end)

    IO.puts("These are the ending hands:\n")
    IO.puts("Player: #{player_end}\nDealer: #{dealer_end}")

    if (player_end > dealer_end and player_end <= 21) or
    (dealer_end > 21 and player_end <= 21) do
      IO.puts("Player won! Congratulations!")
    else
      IO.puts("Dealer won! Better luck next time!")
    end
    IO.puts("-----------")
    new_game = String.trim(IO.gets("Do you want to play again? y/n\n"))

    cond do
      new_game == "y" ->
        game_start()

      new_game == "n" ->
        IO.puts("Thank you for playing!")
        exit(:shutdown)
      true ->
        IO.puts("Something went wrong! / Invalid output!")
    end
  end
end




Blackjack.game_start()
