#!/bin/bash

read -p "What do you want to install? :" appi

sudo apt-get update ${appi}
sudo apt-get upgrade ${appi}
if [ ${?} = 0 ]
then
 echo "Installation was completed succesfully!"
else
  echo "Something went wrong with the installation"
  exit 111
fi
