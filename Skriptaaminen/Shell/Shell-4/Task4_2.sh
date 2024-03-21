#!/bin/bash

VAR1=$RANDOM
VAR2=$RANDOM
VAR3=$RANDOM

ARRAY1=($VAR1 $VAR2 $VAR3)

echo ${VAR1} 
echo ${VAR2}
echo ${VAR3}

Loggeri(){

for index in ${!ARRAY1[@]}
do
  logger -p user.info ${ARRAY1[$index]}
done
}

Loggeri
