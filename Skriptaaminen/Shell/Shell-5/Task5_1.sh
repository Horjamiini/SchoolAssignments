#!/bin/bash

declare ARRAY1

while read -p "Give me value (exit to end and print values):" value
do
if [ ${value} = "Exit" ] || [ ${value} = "exit" ]
  then
   break
else
   ARRAY1+=(${value})
fi
done
echo ${ARRAY1[@]} >> animals.txt
cat animals.txt

