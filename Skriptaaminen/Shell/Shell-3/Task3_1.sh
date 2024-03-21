#!/bin/bash


declare ARRAY1
while true
do
 read -p "Add values to array :" value
  if [ $value = "Exit" ]
  then
  break
  fi
 ARRAY1+=($value)
done

for index in ${!ARRAY1[@]}
do
 echo "${index}:${ARRAY1[$index]}"
done

