#!/bin/bash

Change(){

sed -r -i "s/80/${1}/g; s/index.html/${2}/g" example.conf

}

Change $1 $2
