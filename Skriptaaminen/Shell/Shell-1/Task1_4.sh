#! /bin/bash

read -p "Give me a path to a file you want to copy:" fpath

read -p "Give me path where you want the file to be copied:" dpath

cp ${fpath} ${dpath}

echo "I copied the ${fpath} to ${dpath}"
