#!/bin/bash

export PATH="/usr/local/bin:/usr/bin:/bin:/opt/homebrew/bin:$PATH"

cd /Users/wayne/Documents/Work/FSDM_Oct_24_1_RU || exit

current_branch=$(git rev-parse --abbrev-ref HEAD)

echo "🔄 Выполняется pull из ветки '$current_branch' ($(date))"
git pull origin "$current_branch"
