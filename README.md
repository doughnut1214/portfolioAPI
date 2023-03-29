# portfolioAPI
A small .net API for my portfolio cloud db content.
This API features 2 endpoints: /projects and /projects/id, id being the dynamic parameter.
/projects returns a list of all available projects within the supabase DB.
/projects/{id} returns a project based on its id if existing, or a 404 if db does not contain a project with that id.
