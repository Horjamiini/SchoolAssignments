#!/bin/bash

read -a Parray -p "Give me a paths to a directories you want to count objects: "

count_objects() {
   for index in ${!Parray[@]}
    do
     local VAR1="${Parray[$index]}: $(ls ${Parray[$index]} | wc -l ) objects"
     echo "${VAR1}"
    done
}
count_objects
