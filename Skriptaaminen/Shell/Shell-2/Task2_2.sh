#!/bin/bash

if [ -f /etc/hosts ]
then
  echo "/etc/hosts available"

   if [ -w /etc/hosts ]
   then
    echo "You have permission to edit the file"
   else
    echo "You don't have permission to edit the file"
  fi
fi 

