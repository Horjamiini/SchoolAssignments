#!/bin/bash

read
{
sed 1d $1 |  while IFS="," read -r Manufacturer Model Color Year
do
  echo "----"
  echo "Manufacturer: ${Manufacturer}"
  echo "Model: ${Model}"
  echo "Color: ${Color}"
  echo "Year: ${Year}"
done
} < $1
