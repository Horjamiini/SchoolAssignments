defmodule Employee do
  defstruct [
  firstname: "",
  lastname: "",
  id_number: 0,
  salary: 0,
  job: :none
]

  def new_employee(firstname,lastname) do
    %Employee{firstname: firstname, lastname: lastname, id_number: System.unique_integer([:positive, :monotonic])}
  end

  def promote(employee) do
    cond do
      employee.job == :none ->
        _employee = %{employee | salary: 2000}
        _employee = %{employee | job: :coder}

      employee.job == :coder ->
        _employee = %{employee | salary: 4000}
        _employee = %{employee | job: :designer}

      employee.job == :designer ->
        _employee = %{employee | salary: 6000}
        _employee = %{employee | job: :manager}

      employee.job == :manager ->
        _employee = %{employee | salary: 8000}
        _employee = %{employee | job: :ceo}

      employee.job == :ceo ->
        IO.puts(employee.lastname <> " you are the CEO, you cannot be promoted any further! \n")
        employee

    end
  end

  def demote(employee) do
    cond do
      employee.job == :ceo ->
        _employee = %{employee | salary: 6000}
        _employee = %{employee | job: :manager}

      employee.job == :manager ->
        _employee = %{employee | salary: 4000}
        _employee = %{employee | job: :designer}

      employee.job == :designer ->
        _employee = %{employee | salary: 2000}
        _employee = %{employee | job: :coder}

      employee.job == :coder ->
        _employee = %{employee | salary: 0}
        _employee = %{employee | job: :none}

      employee.job == :none ->
        IO.puts(employee.lastname <> " you are one mistake away from getting fired! \n")
        employee

    end
  end

end

ruut = Employee.new_employee("Ruut","Ana")
lumi = Employee.new_employee("Lumi","Linna")
heli = Employee.new_employee("Heli","Kopteri")


ruut = Employee.promote(ruut)
ruut = Employee.promote(ruut)
ruut = Employee.promote(ruut)
ruut = Employee.promote(ruut)
ruut = Employee.promote(ruut)

lumi = Employee.promote(lumi)
lumi = Employee.promote(lumi)
lumi = Employee.promote(lumi)
lumi = Employee.promote(lumi)
lumi = Employee.demote(lumi)

heli = Employee.promote(heli)
heli = Employee.demote(heli)
heli = Employee.demote(heli)


IO.inspect(ruut)
IO.inspect(lumi)
IO.inspect(heli)
