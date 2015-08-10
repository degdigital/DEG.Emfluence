DEG.Emfluence
=============

This module provides a simple integration with the [Emfluence API v1](https://apidocs.emailer.emfluence.com/v1/).

# Features

1. Save contacts
1. Search for groups

Yup, that's it for now. This module does very little, but it tries to do it very well.

# Motivation

This module was developed out of necessity. We had a need to save contacts into Emfluence, and most of the existing libraries (what little there are) were outdated or bloated.

These are the primary goals for this project:

1. Simplicity: The library should be easy to use, and the API should be intuitive.
2. Stability: As with all software, it will fail sometimes. When it does, the cause should be known, and the remedy should be clear.
3. Readability: The code should be clean and well organized, so that others can enjoy it.

With that in mind, it only does exactly what we need it to, and no more. If you need it to do more, then please feel free to contribute! We will be actively monitoring, reviewing and merging pull requests.

# Authentication

This module currently supports [Application only authentication](https://apidocs.emailer.emfluence.com/v1/#application-only-access-token).

Basically, this means API activities are done as an application, and not as an individual.

We will be adding other authentication support as needed in the future.