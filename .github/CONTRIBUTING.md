# How to contribute

## Making Changes

1. [Fork](http://help.github.com/forking/) on GitHub
1. Clone your fork locally
1. Configure the upstream repo (`git remote add upstream git://github.com/Franklin89/NGitLab`)
1. Create a local branch from the current develop branch (`git checkout -b myBranch`)
1. Work on your feature
1. Rebase if required (see below)
1. Push the branch up to GitHub (`git push origin myBranch`)
1. Send a Pull Request on GitHub

## Handling Updates from Upstream/Master

While you're working away in your branch it's quite possible that your upstream develop may be updated. If this happens you should:

1. [Stash](http://git-scm.com/book/en/Git-Tools-Stashing) any un-committed changes you need to
1. `git checkout develop`
1. `git pull upstream develop`
1. `git checkout myBranch`
1. `git rebase develop myBranch`
1. `git push origin develop` - (optional) this makes sure your remote master is up to date

This ensures that your history is "clean" i.e. you have one branch off from develop followed by your changes in a straight line. Failing to do this ends up with several "messy" merges in your history, which we don't want. This is the reason why you should always work in a branch and you should never be working in, or sending pull requests from, develop.

**If you're working on a long running feature then you may want to do this quite often, rather than run the risk of potential merge issues further down the line.**

## Sending a Pull Request

When you're ready to go you should confirm that you are up to date and rebased with upstream/master (see "Handling Updates from Upstream/Master" above), and then:

1. `git push origin myBranch`
1. Send a descriptive [Pull Request](http://help.github.com/pull-requests/) on GitHub - making sure you have selected the correct branch in the GitHub UI!
1. Wait for @Franklin89 to merge your changes in.

## Style Guidelines

- Indent with 4 spaces, **not** tabs.
- Use the `var` keyword unless the inferred type is not obvious.
- Use the C# type aliases for types that have them, e.g. `int` instead of `Int32`, `string` instead of `String` etc.
- Use meaningful names.
- Wrap `if`, `else` and `using` blocks (or blocks in general, really) in curly braces, even if it's a single line.
- Pay attention to whitespace and extra blank lines
- Absolutely **no** regions