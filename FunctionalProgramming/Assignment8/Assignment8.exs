defmodule Timer do
  use GenServer

  def start_link() do
    GenServer.start_link(__MODULE__, :ok)
  end

  def timer_start(pid, time_in_ms) do
    GenServer.call(pid, time_in_ms)
  end

  def timer_cancel() do
    GenServer.cast(self(), :cancel)
  end

  def init(pid) do
    {:ok, pid}
  end

  def handle_call(time_in_ms, _from, :ok) do
    ref = Process.send_after(self(), :work, time_in_ms)
    {:reply, :wokr, ref}
  end

  def hande_cast(_pid,_request) do
    {:noreply, Process.cancel_timer(self(), :ok)}
  end

  def handle_info(msg,state) do
    cond do
      msg == :work ->
        IO.puts("work")
      msg == :cancel ->
        IO.puts("work stopped")
      true -> "Dont know what to do"
    end

    {:noreply, state}
  end
end

{:ok, pid} = Timer.start_link()
IO.inspect(pid)
Timer.timer_start(pid, 1750)
Timer.timer_cancel()

Process.sleep(4000)
