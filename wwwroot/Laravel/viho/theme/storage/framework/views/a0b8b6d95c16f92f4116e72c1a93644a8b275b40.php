<?php $__env->startSection('title'); ?>Form Builder 1
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Form Builder 1</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Form Builder</li>
		<li class="breadcrumb-item active">Form Builder 1</li>
	<?php echo $__env->renderComponent(); ?>

    <div class="form-builder">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-header pb-0">
                            <h5>Drag & Drop components</h5>
                            <span>Copy the html code from View HTML tab </span>
                        </div>
                        <div class="card-body">
                            <div class="row clearfix form-builder">
                                <div class="col-lg-12 col-xl-6">
                                    <div class="form-builder-header-1">
                                        <ul class="nav nav-primary" id="formtabs"></ul>
                                    </div>
                                    <form class="form-horizontal theme-form" id="components">
                                        <fieldset>
                                            <div class="tab-content"></div>
                                        </fieldset>
                                    </form>
                                </div>
                                <div class="col-lg-12 col-xl-6 lg-mt-col">
                                    <div class="form-builder-header-1">
                                        <h6 class="mt-0">Drag Elements Here</h6>
                                    </div>
                                    <div id="build">
                                        <form class="form-horizontal drag-box" id="target"></form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <?php $__env->startPush('scripts'); ?> 
    <script src="<?php echo e(asset('assets/js/counter/jquery.waypoints.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/counter/jquery.counterup.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/counter/counter-custom.js')); ?>"></script>

    <script src="<?php echo e(asset('assets/js/form-builder/form-builder-1/require.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/form-builder/form-builder-1/main-built.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/builders/form-builder-1.blade.php ENDPATH**/ ?>