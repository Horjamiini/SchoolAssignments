#!/bin/bash

Car_add(){
echo "${1}" >> cars.csv

}

read -p "Give me manufacturer: " Manu
read -p "Give me model: " Model
read -p "Give me year: " Year
read -p "Give me color: " Color

NewCar="${Manu},${Model},${Color},${Year}"

Car_add ${NewCar}

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
