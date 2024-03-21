#!/bin/bash

read -p "Give me a filename or a path to a file you want to remove:" filename

if [ -f ${filename} ] && [ ! -s ${filename} ]
then
  rm ${filename}
  echo "I removed the file"

else
  echo "Error"
fi
