
#!/bin/bash


count_objects() {
  local VAR1=$(ls | wc -l)
  echo "${VAR1}"
}

count_objects
