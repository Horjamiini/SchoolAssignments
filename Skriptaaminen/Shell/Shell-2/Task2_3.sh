#!/bin/bash

for object in $@
do 
  if [ -f $object ]
   then
   echo "$object:file"
  elif [ -d $object ]
   then
   echo "$object:directory"
  else
   echo "$object:other"
  fi
done
