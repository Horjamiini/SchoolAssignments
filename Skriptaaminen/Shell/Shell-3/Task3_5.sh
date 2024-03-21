#!/bin/bash

summa(){
A=$(( $number1 + $number2 ))
echo "$A"
}

vahennys(){
B=$(( $number1 - $number2 ))
echo "$B"
}

kerto(){
C=$(( $number1 * $number2  ))
echo "$C"
}

jako(){
D=$(( $number1 / $number2 ))
echo "$D"
}





set -f

Operations="+ - * / Exit"

PS3='Select: '

select x in $Operations
do
  if [ $x = '+' ] || [ $x = '-' ] || [ $x = '*' ] || [ $x = '/' ]
  then
   read -p "Give me two numbers:" number1 number2
     if [ $x = '+' ]
	 then
	 summa 
     elif [ $x = '-' ]
	then
	vahennys
     elif [ $x = '*' ]
	then
	kerto
     elif [ $x = '/' ]
	then
	jako
	fi 
 fi

  if [ $x = 'Exit' ]
  then
   break
  fi
done
echo "Exiting..."
