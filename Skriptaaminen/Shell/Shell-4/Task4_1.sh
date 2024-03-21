#!/bin/bash

read -p "Give me an URL you want to ping:" urli

pingaus(){
  ping -c 1 ${urli}
   if [ ${?} -ne 0 ]
   then
    return 1
   fi
return 0

}

pingaus

if [ ${?} = 0 ]
  then
  echo "Ping was succesful!"
else
  echo "Error occured with pinging!"
fi

