#!/bin/bash

read -p "Give me a name for new user:" uusikayttaja

if [ $(id -u $uusikayttaja) ]
then
  echo "username not available"

else
sudo  useradd ${uusikayttaja}  -m -s /bin/bash
  echo "I created a new user for ${uusikayttaja}"
fi
