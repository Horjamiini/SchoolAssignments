#! /bin/bash

read -p "Give me a path for a directory you want to see:" dpath

sudo ls ${dpath} | wc -l
