#! /bin/sh

git config --local user.name "traviscibot"
git config --local user.email "traviscibot@travisci.org"
git tag "v$(date +'%Y.%m.%d.%H%M')-$TRAVIS_BRANCH"
