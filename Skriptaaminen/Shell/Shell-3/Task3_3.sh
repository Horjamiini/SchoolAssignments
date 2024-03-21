#!/bin/bash

read -p "Give me a path to a directory you want to count objects: " dpath

count_objects() {
  local VAR1=$(ls ${dpath} | wc -l)
  echo "${VAR1}"
}

count_objects

