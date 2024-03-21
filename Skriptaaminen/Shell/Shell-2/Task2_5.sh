#!/bin/bash

set -f

Operations="+ - * / Exit"

PS3='Select: '

select x in $Operations
do
  if [ $x = '+' ] || [ $x = '-' ] || [ $x = '*' ] || [ $x = '/' ]
 then
   read -p "Give me two numbers:" number1 number2
    A=$(( $number1 $x $number2  ))
    echo "$A"
  fi

  if [ $x = 'Exit' ]
  then
   break
  fi
done
set +f
echo "exiting..."
