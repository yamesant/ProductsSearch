This is a Products Search project.

It exposes a single API endpoint "products/search" to find products in a MongoDB collection.

The collection settings are specified in `appsettings.json`

The search request consists of a group of filters. Each filter is optional. The API returns a list of products that satisfy all included filters.

Each filter is unit-tested on a small in-memory collection with auto-generated products data.