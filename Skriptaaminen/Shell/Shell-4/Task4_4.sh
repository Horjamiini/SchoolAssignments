#!/bin/bash

network_information(){
ipari=$(hostname -i)
hosti=$(hostname)

echo ${ipari}
echo ${hosti}


networkarray=(${ipari} ${hosti})
for index in ${!networkarray[@]}
do
  logger -p user.info -t "network-information" "${networkarray[$index]}"
done
}


network_information
